import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';
import { TopicListingComponent } from './components/topics/topic-listing/topic-listing.component';
import { UserProfileComponent } from './components/users/user-profile/user-profile.component';
import { ThreadListingComponent } from './components/threads/thread-listing/thread-listing.component';
import { CreateThreadComponent } from './components/threads/create-thread/create-thread.component';
import { PostListingComponent } from './components/posts/post-listing/post-listing.component';
import { CreatePostComponent } from './components/posts/create-post/create-post.component';
import { CreateTopicComponent } from './components/topics/create-topic/create-topic.component';
import { AllErrorComponent } from './components/errors/all-error/all-error.component';


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
        path: 'topics/:topicId/create-thread',
        component: CreateThreadComponent
    },
    {
        path: 'threads/:threadId/create-post',
        component: CreatePostComponent
    },
    {
        path: 'topics/create-topic',
        component: CreateTopicComponent
    },
    {
        path: 'threads/:threadId/create-post/:repliedPostId',
        component: CreatePostComponent
    },
    {
        path: 'error',
        component: AllErrorComponent
    },
    { 
        path: '**', 
        redirectTo: '' 
    }
];

export const routing = RouterModule.forRoot(appRoutes);
