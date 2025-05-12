import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import {NavComponent} from './components/nav/nav.component'
import { filter } from 'rxjs';
import { CommonModule } from '@angular/common';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
    NavComponent, CommonModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'client-app';
  isPath: boolean = false;
  
  constructor(private router: Router, private accountService: AccountService) {}
  ngOnInit(): void {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      this.isPath = event.url.includes('admin') || event.url.includes('login');
    });

    this.accountService.check().subscribe();
  }
}
