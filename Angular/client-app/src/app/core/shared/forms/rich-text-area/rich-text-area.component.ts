import {
  Component,
  EventEmitter,
  Output,
  ViewEncapsulation,
  ChangeDetectionStrategy
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { QuillModule } from 'ngx-quill';


@Component({
  standalone: true,
  selector: 'app-rich-text-area',
  imports: [QuillModule, FormsModule],
  templateUrl: './rich-text-area.component.html',
  styleUrl: './rich-text-area.component.css',
  changeDetection: ChangeDetectionStrategy.Eager,
  encapsulation: ViewEncapsulation.None,
})
export class RichTextAreaComponent {

  @Output() changeRichTextArea = new EventEmitter<string>();
  text = "";
  modules = { toolbar: [['bold', 'italic', 'underline'], [{ header: 1 }, { header: 2 }], [{ list: 'ordered' }, { list: 'bullet' }], ['link']] };

  change() {
    this.changeRichTextArea.emit(this.text);
  }
}
