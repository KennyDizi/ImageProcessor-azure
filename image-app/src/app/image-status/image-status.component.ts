import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'image-status',
  templateUrl: './image-status.component.html',
  styleUrls: ['./image-status.component.css']
})
export class ImageStatusComponent implements OnInit {
  @Input() status: Number;

  constructor() { }
  ngOnInit() { }
}
