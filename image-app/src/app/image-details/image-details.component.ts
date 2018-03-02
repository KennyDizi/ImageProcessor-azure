import { Component, OnInit, Input } from '@angular/core';
import { AdultData } from '../adult-data';
import { CategoriesData } from '../categories-data';
import { ColorData } from '../color-data';
import { TagData } from '../tag-data';
import { TypeData } from '../type-data';
import { capitalize, map } from 'lodash';

@Component({
  selector: 'image-details',
  templateUrl: './image-details.component.html',
  styleUrls: ['./image-details.component.css']
})
export class ImageDetailsComponent implements OnInit {
  @Input() adult: AdultData;
  @Input() categories: CategoriesData;
  @Input() color: ColorData;
  @Input() tagData: TagData[];
  @Input() typeData: TypeData;

  constructor() { }

  ngOnInit() {
    this.tagData = map(this.tagData, (tag) => {
      return new TagData(capitalize(tag.name.toString()), tag.confidence);
    });
  }

}
