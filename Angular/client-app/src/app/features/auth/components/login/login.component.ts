
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { UserModel } from '../../models/UserModel';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthStoreService } from '../../services/stores/auth.store.service';

@Component({
  selector: 'app-login',
  imports: [NgbNavModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  constructor(
    private readonly store: AuthStoreService,
    private toastr: ToastrService,
    private router: Router,
  ) {}

  user = {} as UserModel;

  onSubmit() {
    this.store.login(this.user).subscribe({
      next: (user) => {
        this.toastr.success('Login successful');
        this.router.navigateByUrl('/admin');
      },
      error: (error) => {
        this.toastr.error('Login failed');
      },
    });
    this.user = {} as UserModel;
  }
}
