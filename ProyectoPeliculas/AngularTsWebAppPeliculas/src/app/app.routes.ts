import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { TokensComponent } from './components/tokens/tokens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { AdminDetallesComponent } from './components/admin-detalles/admin-detalles.component';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent},
    {path: 'solicitudes/:pg', component: SolicitudesComponent},
    {path: 'tokens/:pg', component: TokensComponent},
    {path: 'usuarios/:pg', component: UsuariosComponent},
    {path: 'adminDetalles', component: AdminDetallesComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'}
]