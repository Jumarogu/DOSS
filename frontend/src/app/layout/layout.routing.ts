import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { AuthGuardService as AuthGuard } from '../services/auth/auth-guard.service';

const LAYOUT_ROUTES: Routes = [
    { path: '', component: LayoutComponent, children: [
        {path: '', redirectTo: 'signin', pathMatch: 'full'},
        { path: 'signin', loadChildren: '../signin/signin.module#SignInModule' },
        { path: 'signup', loadChildren: '../signup/signup.module#SignUpModule' },
        //{ path: 'parent', loadChildren: '../padres/padres.module#PadresModule' },
        { path: 'professor', loadChildren: '../professors/professors.module#ProfessorsModule', canActivate: [AuthGuard]}
    ]}
];

export const LayoutRouting = RouterModule.forChild(LAYOUT_ROUTES);