import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { UserModel } from '../models/UserModel';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [NgbNavModule,FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router,
  ) {}

  user = {} as UserModel;

  onSubmit() {
    this.accountService.login(this.user).subscribe({
      next: (user) => {
        this.toastr.success('Login successful');
        this.router.navigateByUrl('/admin');
      },
      error: (error) => {
        this.toastr.error('Login failed');
      }
    })
    this.user = {} as UserModel;
  }
}
