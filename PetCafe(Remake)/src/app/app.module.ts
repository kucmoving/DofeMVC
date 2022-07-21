import { BrowserModule } from '@angular/platform-browser';
import { forwardRef, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeOneComponent } from './components/pages/home-one/home-one.component';
import { HomeTwoComponent } from './components/pages/home-two/home-two.component';
import { HomeThreeComponent } from './components/pages/home-three/home-three.component';
import { PreloaderComponent } from './components/common/preloader/preloader.component';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { ResumeDetailsComponent } from './components/pages/resume-details/resume-details.component';
import { ComingSoonComponent } from './components/pages/coming-soon/coming-soon.component';
import { ErrorComponent } from './components/pages/error/error.component';
import { AboutComponent } from './components/pages/about/about.component';
import { ContactComponent } from './components/pages/contact/contact.component';
import { FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { PuppyListComponent } from './components/pages/puppy-list/puppy-list.component';
import { PuppyDetailsComponent } from './components/pages/puppy-details/puppy-details.component';
import { NavbarStyleOneComponent } from './components/common/navbar-style-one/navbar-style-one.component';
import { NavbarStyleTwoComponent } from './components/common/navbar-style-two/navbar-style-two.component';
import { FooterStyleTwoComponent } from './components/common/footer-style-two/footer-style-two.component';
import { NavbarStyleThreeComponent } from './components/common/navbar-style-three/navbar-style-three.component';
import { FooterStyleOneComponent } from './components/common/footer-style-one/footer-style-one.component';
import {ToastrModule} from 'ngx-toastr'
import { JwtInterceptor } from './_interceptor/jwt.interceptor';
import {NgxGalleryModule} from '@kolkov/ngx-gallery';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PuppyEditComponent } from './components/pages/puppy-edit/puppy-edit.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import {TimeagoModule} from 'ngx-timeago';
import { MypuppiesComponent } from './components/pages/mypuppies/mypuppies.component';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { MessagesComponent } from './components/pages/messages/messages.component';
import { MemberMessagesComponent } from './components/pages/puppy-messages/puppy-messages.component';
import { LoadingInterceptor } from './_interceptor/loading.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeOneComponent,
    HomeTwoComponent,
    HomeThreeComponent,
    PreloaderComponent,
    LoginComponent,
    RegisterComponent,
    PuppyEditComponent,
    ResumeDetailsComponent,
    MypuppiesComponent,
    ComingSoonComponent,
    ErrorComponent,
    AboutComponent,
    PuppyDetailsComponent,
    PuppyListComponent,
    ContactComponent,
    NavbarStyleOneComponent,
    FooterStyleOneComponent,
    NavbarStyleTwoComponent,
    NavbarStyleThreeComponent,
    FooterStyleTwoComponent,
    MessagesComponent,
    MemberMessagesComponent,

],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),

      NgxGalleryModule,
      BrowserAnimationsModule,
      ReactiveFormsModule,
      PaginationModule.forRoot(),
      TimeagoModule.forRoot(),
      ButtonsModule.forRoot(),
  ],

  providers: [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => MypuppiesComponent) ,multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor,multi:true}],

  bootstrap: [AppComponent]
})

export class AppModule { }
