import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {

  public itemId: number;
  // inject activatedRoute and Router
  // using activated route to ensure right the right nav link is highlighted
  // using router to navigate the click event binded with the next page button
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    //get the value of 'id' from the active route and assign it to the itemId
    //the route metod returns a string, conversion is needed to make it calculable
    this.itemId = Number(this.route.snapshot.params['id']);
    //get updated route value within the same component
    this.route.params.subscribe(
      (params) => {
        this.itemId = +params['id'];
      }
    )
  }
  onNextPage() {
    this.itemId += 1;
    //navigate to the url with itemId increased by 1
    this.router.navigate(['item-detail', this.itemId]);

  }
}
