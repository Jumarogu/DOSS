import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const LAYOUT_ROUTES: Routes = [
    { path: '', component: LayoutComponent, children: [
        //{path: '', redirectTo: '', pathMatch: 'full'},
        //{ path: 'sign-in', loadChildren: '../sign-in/sign-in.module#SignInModule' },

        //{ path: 'padres', loadChildren: '../padres/padres.module#PadresModule' },
        //{ path: 'profesors', loadChildren: '../profesors/profesors.module#ProfesorsModule'}
    ]}
];

export const LayoutRouting = RouterModule.forChild(LAYOUT_ROUTES);