import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms'; // Required for ngModel
import { RoleService } from '../../services/role/role.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-role',
  standalone: true,
  imports: [CommonModule, FormsModule, DialogModule, ButtonModule, InputTextModule, TableModule, ConfirmDialogModule,
    ToastModule],
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit, OnDestroy {
  roles: any[] = []; // Store API response
  displayAddDialog: boolean = false; // To toggle the dialog visibility
  action: string='';

  newRole = {
    roleId : 0,
    roleName: ''
  };

  private dialogObserver!: MutationObserver;

  constructor(private roleService: RoleService, private confirmationService: ConfirmationService, private messageService: MessageService) {}

  ngOnInit() {
    this.loadRoles();

    // Initialize MutationObserver to toggle body blur class
    this.dialogObserver = new MutationObserver(() => {
      const mask = document.querySelector('.p-dialog-mask');
      if (mask && this.displayAddDialog) {
        document.body.classList.add('modal-open');
      } else {
        document.body.classList.remove('modal-open');
      }
    });

    this.dialogObserver.observe(document.body, {
      childList: true,
      subtree: true
    });
  }

  ngOnDestroy() {
    if (this.dialogObserver) {
      this.dialogObserver.disconnect();
    }
    document.body.classList.remove('modal-open'); // Clean up blur if still present
  }

  loadRoles() {
    this.roleService.getRoles().subscribe({
      next: (data) => {
        this.roles = data;
      },
      error: (err) => {
        console.error('Error fetching roles:', err);
      }
    });
  }

  showAddRoleDialog() {
    this.newRole = { roleId : 0, roleName: '' }; // Reset the newRole data
    this.displayAddDialog = true; // Show the dialog
    this.action = 'Add';
  }

  saveRole() {
    if(this.action == 'Add')
    {
      this.roleService.addRole(this.newRole).subscribe({
        next: () => {
          this.loadRoles(); // Refresh the role list
          this.displayAddDialog = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Saved',
            detail: 'Role Saved successfully!'
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to Save Role'
          });
        }
      });
    }
    else{
      this.roleService.editRole(this.newRole).subscribe({
        next: () => {
          this.loadRoles(); // Refresh the role list
          this.displayAddDialog = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Updated',
            detail: 'Role Updated successfully!'
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to Update Role'
          });
        }
      });
    }
  }

  cancelAddRole() {
    this.displayAddDialog = false; // Close the dialog
  }

  onEditRole(role: any) {
    this.newRole = { roleId: role.roleId, roleName: role.roleName };
    this.displayAddDialog = true;
    this.action = 'Edit';  
  }

  onDeleteRole(role: any) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this role?',
      header: 'Confirm Deletion',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Yes, Delete',
      rejectLabel: 'No, Cancel',
      acceptIcon: 'pi pi-check-circle',
      rejectIcon: 'pi pi-times-circle',
      acceptButtonStyleClass: 'custom-accept-button',
      rejectButtonStyleClass: 'custom-reject-button',
      defaultFocus: 'reject',
      accept: () => {
        this.roleService.deleteRole(role.roleId).subscribe({
          next: (response: string) => {
            this.loadRoles();
            this.messageService.add({
              severity: response.includes('Successfully') ? 'success' : 'warn',
              summary: response.includes('Successfully') ? 'Deleted' : 'Warning',
              detail: response
            });
          },
          error: () => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Failed to delete Role'
            });
          }
        });
      },
      reject: () => {
        this.messageService.add({
          severity: 'info',
          summary: 'Cancelled',
          detail: 'Deletion cancelled'
        });
      }
    });
  }
}
