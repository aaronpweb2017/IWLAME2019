using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EliminadorDirectorio
{
    public partial class Marco : Form
    {
        FolderBrowserDialog FBD;
        static List<List<NodoRuta>> arbolRutas;
        static int idNode;
        static string[] fileRoutes;
        static string[] forderRoutes;
        static List<string> routes;
        static List<string> emptyDirectories;
        static Ruta rutaObj;

        public Marco()
        {
            InitializeComponent();
            CenterToScreen();
            FBD = new FolderBrowserDialog();
            idNode = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpenDirectoryFiles_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                String rootDirectoryPath, name, type; long size;
                rootDirectoryPath = FBD.SelectedPath; txtBoxRoute.Text = rootDirectoryPath;
                if ((Directory.GetFiles(rootDirectoryPath).Length + Directory.GetDirectories(rootDirectoryPath).Length) == 0)
                { MessageBox.Show("Este Directorio está vacío"); return; }

                arbolRutas = new List<List<NodoRuta>>(); arbolRutas.Add(new List<NodoRuta>());
                name = GetDirectoryName(rootDirectoryPath); size = 0; type = "Directory";
                rutaObj = new Ruta(rootDirectoryPath, name, type, size);
                arbolRutas[0].Add(new NodoRuta(rutaObj, idNode, 0)); idNode++;
                for (int i = 0; i < arbolRutas.Count; i++)
                {
                    if (arbolRutas[i].Count == 0) { arbolRutas.RemoveAt(i); break; }
                    arbolRutas.Add(new List<NodoRuta>());
                    for (int j = 0; j < arbolRutas[i].Count; j++)
                    {
                        if (i == 1)
                        {
                            if (Directory.Exists(arbolRutas[i][j].info.path))
                                lstBoxDirectoryFiles.Items.Add(arbolRutas[i][j].info.name);
                            else
                                lstBoxDirectoryFiles.Items.Add(arbolRutas[i][j].info.name + " | " + arbolRutas[i][j].info.size + "KB");
                        }
                        if (Directory.Exists(arbolRutas[i][j].info.path))
                            ExpandeDirectorio((i + 1), arbolRutas[i][j], arbolRutas[i][j].idm);
                    }
                }
            }
        }

        static String GetDirectoryName(String route)
        {
            return Path.GetFileName(route);
        }

        static String GetFileName(String route)
        {
            return (new FileInfo(route).Name);
        }

        static long GetFileSize(String route)
        {
            return (new FileInfo(route).Length);
        }

        static void ExpandeDirectorio(int nivel, NodoRuta nodoDirectorio, int idf)
        {
            String name, type; long size;
            forderRoutes = Directory.GetDirectories(nodoDirectorio.info.path);
            fileRoutes = Directory.GetFiles(nodoDirectorio.info.path);
            routes = new List<string>();
            foreach (string forderRoute in forderRoutes) routes.Add(forderRoute);
            foreach (string fileRoute in fileRoutes) routes.Add(fileRoute);
            foreach (string route in routes)
            {
                if (Directory.Exists(route)) { name = GetDirectoryName(route); type = "Directory"; size = 0; }
                else { name = GetFileName(route); type = "File"; size = (GetFileSize(route) / 1024); }
                rutaObj = new Ruta(route, name, type, size);
                arbolRutas[nivel].Add(new NodoRuta(rutaObj, idNode, idf)); idNode++;
            }
        }

        private void btnDetete_Click(object sender, EventArgs e)
        {
            if (arbolRutas == null) { MessageBox.Show("Eliga un Directorio válido."); return; }
            emptyDirectories = new List<string>();
            for (int i = 0; i < arbolRutas.Count; i++)
            {
                for (int j = 0; j < arbolRutas[i].Count; j++)
                {
                    if (!Directory.Exists(arbolRutas[i][j].info.path))
                    {
                        using (FileStream file = File.Open(arbolRutas[i][j].info.path, FileMode.Open))
                        {
                            file.SetLength(0); file.Close(); File.Delete(arbolRutas[i][j].info.path);
                        }
                    }
                    else
                        emptyDirectories.Add(arbolRutas[i][j].info.path);
                }
            }
            for (int i = (emptyDirectories.Count - 1); i > 0; i--)
                Directory.Delete(emptyDirectories[i]);
            lstBoxDirectoryFiles.Items.Clear(); arbolRutas = null;
        }
    }
}