import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterModule, MenubarModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'role-management-new';

  menuItems: MenuItem[] = [];

  ngOnInit() {
    this.menuItems = [
      { label: 'Users', icon: 'pi pi-users', routerLink: ['/users'], styleClass: 'menu-spacing' },
      { label: 'Roles', icon: 'pi pi-briefcase', routerLink: ['/roles'], styleClass: 'menu-spacing' },
      { label: 'Role Rights', icon: 'pi pi-spin pi-cog', routerLink: ['/rolerights'], styleClass: 'menu-spacing' }
    ];
  }
  
}
