import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import {NavComponent} from './components/nav/nav.component'
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
    NavComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'client-app';
  isAdminPath: boolean = false;
  
  constructor(private router: Router) {}
  ngOnInit(): void {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.isAdminPath = this.router.url.includes('admin');
    });
  }
}
