import {
  Component,
  EventEmitter,
  Output,
  ViewEncapsulation,
} from '@angular/core';
import { ChangeEvent, CKEditorModule } from '@ckeditor/ckeditor5-angular';
import {
  Base64UploadAdapter,
  BlockQuote,
  Bold,
  ClassicEditor,
  Code,
  CodeBlock,
  Essentials,
  EventInfo,
  FontBackgroundColor,
  FontColor,
  FontFamily,
  Heading,
  ImageBlock,
  ImageEditing,
  ImageInline,
  ImageInsert,
  ImageResize,
  ImageUpload,
  ImageUploadUI,
  Indent,
  Italic,
  Link,
  List,
  Mention,
  Paragraph,
  Strikethrough,
  Subscript,
  Superscript,
  TodoList,
  Undo,
} from 'ckeditor5';

@Component({
  standalone: true,
  selector: 'app-rich-text-area',
  imports: [CKEditorModule],
  templateUrl: './rich-text-area.component.html',
  styleUrl: './rich-text-area.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class RichTextAreaComponent {
  public Editor = ClassicEditor;
  public config = {
    toolbar: [
      'undo',
      'redo',
      '|',
      'heading',
      '|',
      'fontfamily',
      'fontsize',
      'fontColor',
      'fontBackgroundColor',
      '|',
      'bold',
      'italic',
      'strikethrough',
      'subscript',
      'superscript',
      'code',
      '|',
      'link',
      'uploadImage',
      'blockQuote',
      'codeBlock',
      '|',
      'bulletedList',
      'numberedList',
      'todoList',
      'outdent',
      'indent',
    ],
    plugins: [
      Bold,
      Essentials,
      Italic,
      Mention,
      Paragraph,
      Undo,
      List,
      Heading,
      FontFamily,
      FontColor,
      FontBackgroundColor,
      Strikethrough,
      Subscript,
      Superscript,
      Code,
      Link,
      Image,
      BlockQuote,
      CodeBlock,
      TodoList,
      Indent,
      ImageBlock,
      ImageUpload,
      ImageInsert,
      ImageUploadUI,
      Base64UploadAdapter,
      ImageEditing,
      //ContextPlugin,
      //ImageResizeEditing,
      ImageResize,
      ImageInline,
    ],

    resourceType: 'Images',

    //licenseKey: '<YOUR_LICENSE_KEY>',
    // mention: {
    //     Mention configuration
    // }
  } as any;
  @Output() changeRichTextArea = new EventEmitter<string>();

  change(event: ChangeEvent) {
    this.changeRichTextArea.emit(event.editor.getData());
  }
}
