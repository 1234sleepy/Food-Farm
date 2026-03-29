import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { filter } from 'rxjs';
import { CommonModule } from '@angular/common';
import { NgxSpinnerComponent } from "ngx-spinner";
import { NavComponent } from './core/layout/nav/nav.component';
import { AuthStoreService } from './features/auth/services/stores/auth.store.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
    NavComponent, CommonModule, NgxSpinnerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'client-app';
  isPath: boolean = false;

  constructor(private router: Router, private authService: AuthStoreService) {}
  ngOnInit(): void {

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      this.isPath = event.url.includes('admin') || event.url.includes('login');
    });

    this.authService.check().subscribe();
  }
}
