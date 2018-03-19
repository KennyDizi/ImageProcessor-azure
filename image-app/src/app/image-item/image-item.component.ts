import { Component, Input } from '@angular/core';
import { Image } from '../image';
import { ImageStatusComponent } from '../image-status/image-status.component';
import { ImageDetailsComponent } from '../image-details/image-details.component';

@Component({
  selector: 'image-item',
  templateUrl: './image-item.component.html',
  styleUrls: ['./image-item.component.css']
})
export class ImageItemComponent {

  @Input() image: Image;
  constructor() { }

}
