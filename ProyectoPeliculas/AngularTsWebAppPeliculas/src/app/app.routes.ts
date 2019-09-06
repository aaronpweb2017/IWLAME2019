import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { TokensComponent } from './components/tokens/tokens.component';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent},
    {path: 'solicitudes/:pg', component: SolicitudesComponent},
    {path: 'tokens/:pg', component: TokensComponent},
    //{path: 'model/:id', component: ModelComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'}
]