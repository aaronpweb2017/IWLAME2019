//Modules (imports):
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';
import {ModalModule} from 'ngx-bootstrap/modal'

//Components (declarations):
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { TopNavbarComponent } from './components/topnavbar/topnavbar.component';
import { SidenavbarComponent } from './components/sidenavbar/sidenavbar.component';
import { HomeComponent } from './components/home/home.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { TokensComponent } from './components/tokens/tokens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { FormatoComponent } from './components/detalles/formatos/formatos.component';
import { TiposResolucionComponent } from './components/detalles/resoluciones/tipos-resolucion/tipos-resolucion.component';
import { ValoresResolucionComponent } from './components/detalles/resoluciones/valores-resolucion/valores-resolucion.component';
import { RelacionesAspectoComponent } from './components/detalles/resoluciones/relaciones-aspecto/relaciones-aspecto.component';
import { ResolucionesComponent } from './components/detalles/resoluciones/resoluciones/resoluciones.component';
import { DetallesTecnicosComponent } from './components/detalles/detalles-tecnicos/detalles-tecnicos.component';
import { AdminDetallesComponent } from './components/admin-detalles/admin-detalles.component';
import { ModalActualizacionComponent } from './components/modals/modal-actualizacion/modal-actualizacion.component';
import { ModalEliminacionComponent } from './components/modals/modal-eliminacion/modal-eliminacion.component';
import { FooterComponent } from './components/footer/footer.component';

//Services (providers):
import { GlobalService } from './global.service';
import { UsuariosService } from './services/usuarios.service';
import { SolicitudesService } from './services/solicitudes.service';
import { DetallesTecnicosService } from './services/detalles-tecnicos.service';
import { VistasService } from './services/vistas.service';

//Global variables:
import { appRoutes } from './app.routes';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes,
      { onSameUrlNavigation: 'reload' }),
    BrowserAnimationsModule,
    NgxPaginationModule,
    ToastrModule.forRoot({
      timeOut: 1500,
      positionClass: 'toast-top-full-width',
      preventDuplicates: true
    }),
    ModalModule.forRoot()
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    TopNavbarComponent,
    SidenavbarComponent,
    HomeComponent,
    SolicitudesComponent,
    TokensComponent,
    UsuariosComponent,
    FormatoComponent,
    TiposResolucionComponent,
    ValoresResolucionComponent,
    RelacionesAspectoComponent,
    ResolucionesComponent,
    DetallesTecnicosComponent,
    AdminDetallesComponent,
    ModalActualizacionComponent,
    ModalEliminacionComponent,
    FooterComponent
  ],
  providers: [GlobalService, UsuariosService,
    SolicitudesService, DetallesTecnicosService, VistasService],
  bootstrap: [AppComponent]
})

export class AppModule { }