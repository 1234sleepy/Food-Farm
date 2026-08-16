import { CommonModule } from '@angular/common';
import { Component, ChangeDetectionStrategy } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CardStoreService } from '../../../features/cart/services/storage/card.store.service';


@Component({
  selector: 'app-nav',
  imports: [CommonModule, RouterLink],
  templateUrl: './nav.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
  styleUrl: './nav.component.css'
})
export class NavComponent {
  constructor(public cardService : CardStoreService) {  }
}
