import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { BaseUrlInterceptor } from './interceptors/base-url.interceptor';
import { LoginComponent } from './components/authentication/login/login.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';
import { routing } from './app.routing';
import { TopicListingComponent } from './components/topics/topic-listing/topic-listing.component';
import { AuthenticationService } from './services/authentication/authentication.service';
import { UserProfileComponent } from './components/users/user-profile/user-profile.component';
import { ThreadListingComponent } from './components/threads/thread-listing/thread-listing.component';
import { PostListingComponent } from './components/posts/post-listing/post-listing.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    RegistrationComponent,
    TopicListingComponent,
    UserProfileComponent,
    ThreadListingComponent,
    PostListingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    routing
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: BaseUrlInterceptor, multi: true },
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
