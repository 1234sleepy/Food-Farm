import { Component } from '@angular/core';
import { AuthStoreService } from '../../services/stores/auth.store.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserModel } from '../../models/UserModel';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { UserRegisterModel } from '../../models/UserRegisterModel';

@Component({
  imports: [NgbNavModule, FormsModule],
  selector: 'app-register-user',
  styleUrl: './register-user.component.css',
  templateUrl: './register-user.component.html',
})
export class RegisterUserComponent {
    constructor(
    private readonly store: AuthStoreService,
    private toastr: ToastrService,
    private router: Router,
  ) {}

    user = {} as UserRegisterModel;
  
    onSubmit() {
      this.store.register(this.user).subscribe({
        next: (user) => {
          this.toastr.success('Register successful');
        },
        error: (error) => {
          this.toastr.error('Register failed');
        },
      });
      this.user = {} as UserRegisterModel;
    }
}
