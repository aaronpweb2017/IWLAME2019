import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app.routes';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { GlobalService } from './global.service';
import { UsuariosService } from './services/usuarios.service';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SolicitudesComponent } from './components/solicitudes/solicitudes.component';
import { SolicitudesService } from './services/solicitudes.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    HomeComponent,
    SolicitudesComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes,
      { onSameUrlNavigation: 'reload' }),
    ToastrModule.forRoot({
      timeOut: 1500,
      positionClass: 'toast-top-full-width',
      preventDuplicates: true}),
    RouterModule.forRoot(appRoutes,
      { onSameUrlNavigation: 'reload' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [GlobalService, UsuariosService, SolicitudesService],
  bootstrap: [AppComponent]
})
export class AppModule { }