import { Component, Input, input, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-description-tab',
  imports: [],
  templateUrl: './description-tab.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
  styleUrl: './description-tab.component.css'
})
export class DescriptionTabComponent {

  @Input() description: string = '';

}
