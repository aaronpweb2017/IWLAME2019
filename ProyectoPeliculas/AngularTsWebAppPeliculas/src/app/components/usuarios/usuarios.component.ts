import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: []
})
export class UsuariosComponent implements OnInit {
  currentPage: number;
  paginationConfig: any;
  usuarios: Usuario[];
  decrypts: boolean[];
  passwords: string[];

  constructor(private usuariosService: UsuariosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.currentPage = this.route.snapshot.params['pg'];
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.usuarios = []; this.decrypts = []; this.passwords = [];
    this.usuariosService.getUsuarios().subscribe(
      usuarios => {
        this.usuarios = usuarios;
        this.decrypts = new Array(this.usuarios.length).fill(false);
        this.passwords = new Array(this.usuarios.length).fill("");
        this.paginationConfig = {
          itemsPerPage: 5,
          currentPage: this.currentPage,
          totalItems: this.usuarios.length
        };
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  decryptPassword(index: number, id_usuario: number) {
    this.usuariosService.getDecryptedPassword(id_usuario).subscribe(
      response => {
        if (response) {
          this.decrypts[index] = true;
          this.passwords[index] = response; return;
        }
        //this.toastrService.error("Desencriptación fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  encryptPassword(index: number) {
    this.decrypts[index] = false;
    this.passwords[index] = "";
  }

  actualizarUsuario(usuario: Usuario) {
    this.usuariosService.actualizarUsuario(usuario).subscribe(
      response => {
        if (response) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/usuarios', this.currentPage]); return;
        }
        //this.toastrService.error("Actualización fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarUsuario(id_usuario: number) {
    this.usuariosService.eliminarUsuario(id_usuario).subscribe(
      response => {
        if (response) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/usuarios', this.currentPage]); return;
        }
        //this.toastrService.error("Eliminación fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.router.navigate(['/usuarios', this.currentPage]);
  }
}