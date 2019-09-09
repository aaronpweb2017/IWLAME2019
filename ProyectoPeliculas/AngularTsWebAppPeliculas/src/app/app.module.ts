//Modules (imports):
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgxPaginationModule} from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';

//Components (declarations):
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { TopNavbarComponent } from './components/topnavbar/topnavbar.component';
import { SidenavbarComponent } from './components/sidenavbar/sidenavbar.component';
import { HomeComponent } from './components/home/home.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { TokensComponent } from './components/tokens/tokens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { ActualizacionComponent } from './components/modals/actualizacion/actualizacion.component';

//Services (providers):
import { GlobalService } from './global.service';
import { UsuariosService } from './services/usuarios.service';
import { SolicitudesService } from './services/solicitudes.service';
import { VistasService } from './services/vistas.service';

//Global variables:
import { appRoutes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TopNavbarComponent,
    SidenavbarComponent,
    HomeComponent,
    SolicitudesComponent,
    TokensComponent,
    UsuariosComponent,
    ActualizacionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes,
      { onSameUrlNavigation: 'reload' }),
    FormsModule,
    BrowserAnimationsModule,
    NgxPaginationModule,
    ToastrModule.forRoot({
      timeOut: 1500,
      positionClass: 'toast-top-full-width',
      preventDuplicates: true })
      
  ],
  providers: [GlobalService, UsuariosService,
    SolicitudesService, VistasService],
  bootstrap: [AppComponent]
})

export class AppModule { }