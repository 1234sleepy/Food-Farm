import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-description-tab',
  imports: [],
  templateUrl: './description-tab.component.html',
  styleUrl: './description-tab.component.css'
})
export class DescriptionTabComponent {

  @Input() description: string = '';

}
