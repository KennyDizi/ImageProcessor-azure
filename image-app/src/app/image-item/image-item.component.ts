import { Component, OnInit, Input } from '@angular/core';
import { Image } from '../image';
import { ImageStatusComponent } from '../image-status/image-status.component';
import { ImageDetailsComponent } from '../image-details/image-details.component';

@Component({
  selector: '[image-item]',
  templateUrl: './image-item.component.html',
  styleUrls: ['./image-item.component.css']
})
export class ImageItemComponent implements OnInit {

  @Input() image: Image;
  constructor() { }

  ngOnInit() {
  }

}
