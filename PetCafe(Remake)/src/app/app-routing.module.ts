import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './components/pages/about/about.component';
import { ComingSoonComponent } from './components/pages/coming-soon/coming-soon.component';
import { ContactComponent } from './components/pages/contact/contact.component';
import { ErrorComponent } from './components/pages/error/error.component';
import { MypuppiesComponent } from './components/pages/mypuppies/mypuppies.component';
import { HomeOneComponent } from './components/pages/home-one/home-one.component';
import { HomeThreeComponent } from './components/pages/home-three/home-three.component';
import { HomeTwoComponent } from './components/pages/home-two/home-two.component';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { ResumeDetailsComponent } from './components/pages/resume-details/resume-details.component';
import { PuppyDetailsComponent } from './components/pages/puppy-details/puppy-details.component';
import { PuppyListComponent } from './components/pages/puppy-list/puppy-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { PuppyEditComponent } from './components/pages/puppy-edit/puppy-edit.component';
import { MessagesComponent } from './components/pages/messages/messages.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [

    {path: 'home-two', component: HomeTwoComponent},
    {path: 'home-three', component: HomeThreeComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'about', component: AboutComponent},
    {path: '', component: HomeOneComponent},
    {
        path:'',
        runGuardsAndResolvers: "always",
        canActivate: [AuthGuard],
        children:[
            {path: 'puppy-edit', component: PuppyEditComponent, canDeactivate:[PreventUnsavedChangesGuard]},
            {path: 'puppy-edit', component: PuppyEditComponent},
            {path: 'single-resume', component: ResumeDetailsComponent},
            {path: 'message', component: MessagesComponent},
            {path: 'mypuppies', component: MypuppiesComponent},
            {path: 'coming-soon', component: ComingSoonComponent},
            {path: 'error', component: ErrorComponent},
            {path: 'puppy-list', component: PuppyListComponent},
            {path: 'puppy-list/:username', component: PuppyDetailsComponent}

        ]
    },
    {path: '**', component: ErrorComponent, pathMatch: "full"},];

@NgModule({
    imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
    exports: [RouterModule]
})
export class AppRoutingModule {}
