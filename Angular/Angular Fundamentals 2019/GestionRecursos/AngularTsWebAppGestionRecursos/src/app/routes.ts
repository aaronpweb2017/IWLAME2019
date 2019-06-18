import { Routes } from '@angular/router';
import { LogInComponent } from './components/login/log-in.component';
import { EmpleadosIndexComponent } from './components/empleados/empleados-index.component';
import { EmpleadosCreateComponent } from './components/empleados/empleados-create.component';
import { EmpleadosEditComponent } from './components/empleados/empleados-edit.component';
import { ProyectosIndexComponent } from './components/proyectos/proyectos-index.component';
import { ProyectosCreateComponent } from './components/proyectos/proyectos-create.component';
import { ProyectosEditComponent } from './components/proyectos/proyectos-edit.component';
import { AsignacionesIndexComponent } from './components/asignaciones/asignaciones-index.component';
import { AsignacionesCreateComponent } from './components/asignaciones/asignaciones-create.component';
import { AsignacionesEditComponent } from './components/asignaciones/asignaciones-edit.component';

export const appRoutes: Routes = [
    {path: 'index', component: LogInComponent},
    {path: 'empleados/index', component: EmpleadosIndexComponent},
    {path: 'empleados/create', component: EmpleadosCreateComponent},
    {path: 'empleados/edit/:id_empleado', component: EmpleadosEditComponent},
    {path: 'empleados', redirectTo: '/empleados/index', pathMatch: 'full'},
    {path: 'proyectos/index', component: ProyectosIndexComponent},
    {path: 'proyectos/create', component: ProyectosCreateComponent},
    {path: 'proyectos/edit/:id_proyecto', component: ProyectosEditComponent},
    {path: 'proyectos', redirectTo: '/proyectos/index', pathMatch: 'full'},
    {path: 'asignaciones/index', component: AsignacionesIndexComponent},
    {path: 'asignaciones/create', component: AsignacionesCreateComponent},
    {path: 'asignaciones/edit/:id_asignacion', component: AsignacionesEditComponent},
    {path: 'asignaciones', redirectTo: '/asignaciones/index', pathMatch: 'full'},
    {path: '', redirectTo: '/index', pathMatch: 'full'}
]