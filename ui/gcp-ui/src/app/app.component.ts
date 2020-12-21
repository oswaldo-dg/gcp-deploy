import { Component } from '@angular/core';
import { pipe } from 'rxjs';
import { DemoService } from 'src/services/demo-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'gcp-ui';

public w: unknown[]=[];

constructor(private s: DemoService){
  
}

  public CallAPI() {
    this.s.getData().subscribe(r=>{
      this.w = r;
    })
  }

}
