import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const LAYOUT_ROUTES: Routes = [
    { path: '', component: LayoutComponent, children: [
        {path: '', redirectTo: 'signin', pathMatch: 'full'},
        { path: 'signin', loadChildren: '../signin/signin.module#SignInModule' },
        { path: 'home', loadChildren: '../home/home.module#HomeModule' },
        //{ path: 'padres', loadChildren: '../padres/padres.module#PadresModule' },
        //{ path: 'profesors', loadChildren: '../profesors/profesors.module#ProfesorsModule'}
    ]}
];

export const LayoutRouting = RouterModule.forChild(LAYOUT_ROUTES);