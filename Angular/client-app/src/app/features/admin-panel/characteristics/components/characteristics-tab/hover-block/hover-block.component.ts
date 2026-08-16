
import { Component, EventEmitter, Input, Output, ChangeDetectionStrategy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CharacteristicModel } from '../../../../../product/models/characteristicModel';

@Component({
  selector: 'app-hover-block',
  imports: [FormsModule],
  templateUrl: './hover-block.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
  styleUrl: './hover-block.component.css',
})
export class HoverBlockComponent {
  model = {} as CharacteristicModel;
  gr: CharacteristicModel[] = [];
  @Input() isAction: boolean = false;
  @Input() entity = {} as CharacteristicModel;
  @Output() addGroupButtonClick: EventEmitter<CharacteristicModel> =
    new EventEmitter();
  @Output() addCharacteristicButtonClick: EventEmitter<CharacteristicModel> =
    new EventEmitter();

  addGroupBetween() {
    this.addGroupButtonClick.emit(this.entity);
  }

  addCharacteristicBetween() {
    this.addCharacteristicButtonClick.emit(this.entity);
  }
}
