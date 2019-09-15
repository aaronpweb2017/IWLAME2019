import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { TokensComponent } from './components/tokens/tokens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';

import { FormatoComponent } from './components/detalles/formato/formato.component';
import { TiposResolucionComponent } from './components/detalles/resoluciones/tipos-resolucion/tipos-resolucion.component';
import { ValoresResolucionComponent } from './components/detalles/resoluciones/valores-resolucion/valores-resolucion.component';
import { RelacionesAspectoComponent } from './components/detalles/resoluciones/relaciones-aspecto/relaciones-aspecto.component';
import { ResolucionesComponent } from './components/detalles/resoluciones/resoluciones/resoluciones.component';
import { DetallesTecnicosComponent } from './components/detalles/detalles-tecnicos/detalles-tecnicos.component';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent},
    {path: 'solicitudes/:pg', component: SolicitudesComponent},
    {path: 'tokens/:pg', component: TokensComponent},
    {path: 'usuarios/:pg', component: UsuariosComponent},
    {path: 'formatos/:pg', component: FormatoComponent},
    {path: 'tiposResolucion/:pg', component: TiposResolucionComponent},
    {path: 'valoresResolucion/:pg', component: ValoresResolucionComponent},
    {path: 'relacionesAspecto/:pg', component: RelacionesAspectoComponent},
    {path: 'resoluciones/:pg', component: ResolucionesComponent},
    {path: 'detallesTecnicos/:pg', component: DetallesTecnicosComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'}
]