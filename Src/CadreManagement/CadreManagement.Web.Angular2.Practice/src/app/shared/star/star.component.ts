import { Component, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'ai-star',
    templateUrl: './star.component.html',
    styleUrls: ['/star.component.css']
})
export class StarComponent implements OnChanges {
    @Input()
    public rating: number;
    private starWidth: number;


    @Output()
    public ratingClicked: EventEmitter<string> = new EventEmitter<string>();

    public ngOnChanges(): void {
        this.starWidth = this.rating * 86 / 5;
    }

    public onClick(): void {
        this.ratingClicked.emit(`The rating ${this.rating} was clicked`);
    }
}