import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';
import { TopicListingComponent } from './components/topics/topic-listing/topic-listing.component';
import { UserProfileComponent } from './components/users/user-profile/user-profile.component';
import { ThreadListingComponent } from './components/threads/thread-listing/thread-listing.component';
import { PostListingComponent } from './components/posts/post-listing/post-listing.component';


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
        path: 'userprofile/:id',
        component: UserProfileComponent
    },
    {
        path: 'threads/:topicId',
        component: ThreadListingComponent
    },
    {
        path: 'posts/:threadId',
        component: PostListingComponent
    },
    { 
        path: '**', 
        redirectTo: '' 
    }
];

export const routing = RouterModule.forRoot(appRoutes);