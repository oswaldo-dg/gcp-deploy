import { environment } from './../environments/environment';
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
name: string = '';
constructor(private s: DemoService){
  this.name = environment.url;
}

  public CallAPI() {
    console.log(this.name);
    this.s.getData(this.name).subscribe(r=>{
      this.w = r;
    })
  }

}
