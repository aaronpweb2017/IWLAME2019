import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HeroesComponent } from './components/heroes/heroes.component';
import { HeroeComponent } from './components/heroe/heroe.component';
import { AboutComponent } from './components/about/about.component';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'heroes', component: HeroesComponent},
    {path: 'about', component: AboutComponent},
    {path: 'heroe/:id', component: HeroeComponent},
    {path: '', redirectTo: '/home', pathMatch: 'full'}
]