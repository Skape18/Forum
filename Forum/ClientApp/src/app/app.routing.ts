import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';
import { TopicListingComponent } from './components/topics/topic-listing/topic-listing.component';


const appRoutes: Routes = [
    { 
        path: '', 
        component: TopicListingComponent, 
        pathMatch: 'full'
    },
    { 
        path: 'topics', 
        component: TopicListingComponent
    },
    { 
        path: 'login', 
        component: LoginComponent
    },
    {
        path: 'registration',
        component: RegistrationComponent
    },
    { 
        path: '**', 
        redirectTo: '' 
    }
];

export const routing = RouterModule.forRoot(appRoutes);