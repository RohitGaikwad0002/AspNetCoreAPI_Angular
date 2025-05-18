import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { RoleRightsService } from '../../services/role-rights/role-rights.service';

@Component({
  selector: 'app-role-rights',
  standalone: true,
  imports: [TableModule, CheckboxModule, ButtonModule, FormsModule],
  templateUrl: './role-rights.component.html',
  styleUrl: './role-rights.component.css'
})
export class RoleRightsComponent {
  rolerights: any[] = [];

  constructor(private roleRightsService: RoleRightsService) {}

  ngOnInit() {
    this.loadRoleRights();
  }

  loadRoleRights() {
    this.roleRightsService.getAllRoleRights().subscribe({
      next: (data) => {
        console.log(data);
        // Initialize permissions for each role - each set has their own flags.
        this.rolerights = data.map((role: any) => ({
          roleRightId : role.roleRightId,
          roleId: role.roleId,
          roleName: role.roleName,
          fullAccess: role.fullAccess ?? false,
          canView: role.canView ?? false,
          canAdd: role.canAdd ?? false,
          canEdit: role.canEdit ?? false,
          canDelete: role.canDelete ?? false,
          canImport: role.canImport ?? false,
          canExport: role.canExport ?? false
        }));
      },
      error: (err) => {
        console.error('Error fetching roles:', err);
      }
    });
  }

  updateRoleRights() {
    const selectedRights = this.rolerights.filter(r =>
        r.fullAccess || r.canView || r.canAdd || r.canEdit || r.canDelete || r.canImport || r.canExport
    ).map(r => ({
      roleRightId : r.roleRightId,
      roleId: r.roleId, // explicitly include roleId
      roleName: r.roleName,
      canView: r.canView || false,
      canAdd: r.canAdd || false,
      canEdit: r.canEdit || false,
      canDelete: r.canDelete || false,
      canImport: r.canImport || false,
      canExport: r.canExport || false,
      fullAccess: r.fullAccess || false
    }));
    if (selectedRights.length === 0) {
      alert('Please select at least one permission.');
      return;
    }

    this.roleRightsService.updateRoleRights(selectedRights).subscribe({
      next: () => {
        alert('Role rights saved successfully.');
      },
      error: (err) => {
        console.error('Error saving role rights:', err);
        alert('An error occurred while saving.');
      }
    });
  }
}
