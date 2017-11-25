import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const LAYOUT_ROUTES: Routes = [
    { path: '', component: LayoutComponent, children: [
        {path: '', redirectTo: 'signup', pathMatch: 'full'},
        { path: 'signup', loadChildren: '../signup/signup.module#SignUpModule' },
        { path: 'signin', loadChildren: '../signin/signin.module#SignInModule' }
        //{ path: 'padres', loadChildren: '../padres/padres.module#PadresModule' },
        //{ path: 'profesors', loadChildren: '../profesors/profesors.module#ProfesorsModule'}
    ]}
];

export const LayoutRouting = RouterModule.forChild(LAYOUT_ROUTES);