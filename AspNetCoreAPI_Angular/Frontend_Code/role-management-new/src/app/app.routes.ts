import { Routes } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { RoleComponent } from './components/role/role.component';
import { RoleRightsComponent } from './components/role-rights/role-rights.component';

export const routes: Routes = [
  { path: '', redirectTo: 'users', pathMatch: 'full' },
  { path: 'users', component: UserComponent },
  { path: 'roles', component: RoleComponent },
  { path: 'rolerights', component: RoleRightsComponent },
];
