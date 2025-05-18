import { Component, OnInit, OnDestroy } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms'; // Required for ngModel
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user/user.service';
import { RoleService } from '../../services/role/role.service';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, FormsModule, DialogModule, ButtonModule, InputTextModule, TableModule, DropdownModule, ConfirmDialogModule,
    ToastModule],
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit, OnDestroy {
  users: any[] = []; // Store API response
  roles: any[] = []; // Store API response
  action: string='';

  displayAddDialog: boolean = false;
  newUser = {
    userId: 0,
    userName: '',
    email: '',
    roleId: null,
    roleName: '' 
  };

  private dialogObserver!: MutationObserver;

  constructor(private userService: UserService, private roleService: RoleService, 
    private confirmationService: ConfirmationService, private messageService: MessageService
        ) {}

  ngOnInit() {
    this.loadUsers();
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

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
      },
      error: (err) => {
        console.error('Error fetching users:', err);
      }
    });
  }

  showAddUserDialog() {
    this.newUser = { userId: 0, userName: '', email: '',  roleId: null, roleName: '' };
    this.displayAddDialog = true;
    this.action = 'Add';
  }

  saveUser() {
    if(this.action == 'Add')
    {
      this.userService.addUser(this.newUser).subscribe({
        next: () => {
          this.loadUsers(); // Refresh the user list
          this.displayAddDialog = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Saved',
            detail: 'User Saved successfully!'
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to Save user'
          });
        }
      });
    }
    else{
      this.userService.editUser(this.newUser).subscribe({
        next: () => {
          this.loadUsers(); // Refresh the user list
          this.displayAddDialog = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Updated',
            detail: 'User Updated successfully!'
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to Update user'
          });
        }
      });
    }
  }

  cancelAddUser() {
    this.displayAddDialog = false;
  }

  onEditUser(user: any) {
    this.newUser = { userId: user.userId, userName: user.userName, email: user.email,  roleId: user.roleId, roleName: '' };
    this.displayAddDialog = true;
    this.action = 'Edit';
  }

  onDeleteUser(user: any) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this user?',
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
        this.userService.deleteUser(user.userId).subscribe({
          next: () => {
            this.loadUsers();
            this.messageService.add({
              severity: 'success',
              summary: 'Deleted',
              detail: 'User deleted successfully!'
            });
          },
          error: () => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Failed to delete user'
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
}
