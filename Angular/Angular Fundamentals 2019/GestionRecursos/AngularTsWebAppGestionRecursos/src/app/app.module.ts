import { appRoutes } from './routes';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { AlertModule } from 'ngx-bootstrap';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { EmpleadosService } from './services/empleados-service';
import { ProyectosService } from './services/proyectos-service';
import { NavBarComponent } from './components/nav/navbar.component';
import { LogInComponent } from './components/login/log-in.component';
import { AsignacionesService } from './services/asignaciones-service';
import { IndexMenuComponent } from './components/menu/index-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmpleadosIndexComponent } from './components/empleados/empleados-index.component';
import { EmpleadosCreateComponent } from './components/empleados/empleados-create.component';
import { EmpleadosEditComponent } from './components/empleados/empleados-edit.component';
import { EmpleadosDeleteComponent } from './components/empleados/empleados-delete.component';
import { ProyectosIndexComponent } from './components/proyectos/proyectos-index.component';
import { ProyectosCreateComponent } from './components/proyectos/proyectos-create.component';
import { ProyectosEditComponent } from './components/proyectos/proyectos-edit.component';
import { ProyectosDeleteComponent } from './components/proyectos/proyectos-delete.component';
import { AsignacionesIndexComponent } from './components/asignaciones/asignaciones-index.component';
import { AsignacionesCreateComponent } from './components/asignaciones/asignaciones-create.component';
import { AsignacionesEditComponent } from './components/asignaciones/asignaciones-edit.component';
import { AsignacionesDeleteComponent } from './components/asignaciones/asignaciones-delete.component';

@NgModule({
  declarations: [
    LogInComponent,
    IndexMenuComponent,
    EmpleadosIndexComponent,
    EmpleadosCreateComponent,
    EmpleadosEditComponent,
    EmpleadosDeleteComponent,
    ProyectosIndexComponent,
    ProyectosCreateComponent,
    ProyectosEditComponent,
    ProyectosDeleteComponent,
    AsignacionesIndexComponent,
    AsignacionesCreateComponent,
    AsignacionesEditComponent,
    AsignacionesDeleteComponent,
    NavBarComponent],
  imports: [
    AlertModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    NgxPaginationModule,
    ToastrModule.forRoot({
      timeOut: 1000,
      positionClass: 'toast-top-center',
      preventDuplicates: true}),
    FormsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule],
  providers: [EmpleadosService,
    ProyectosService, AsignacionesService],
  bootstrap: [LogInComponent]
})

export class AppModule { }