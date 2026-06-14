import {
  Component,
  EventEmitter,
  Input,
  ViewEncapsulation,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HoverBlockComponent } from './hover-block/hover-block.component';
import { ProductStoreService } from '../../../../product/services/storages/product.store.service';
import { AdminProductStoreService } from '../../../products/stores/admin-product.store.service';
import { CharacteristicModel } from '../../../../product/models/characteristicModel';

@Component({
  standalone: true,
  selector: 'app-characteristics-tab',
  imports: [CommonModule, FormsModule, HoverBlockComponent],
  templateUrl: './characteristics-tab.component.html',
  styleUrl: './characteristics-tab.component.css',
  // encapsulation: ViewEncapsulation.None,
})
export class CharacteristicsTabComponent {
  id: string = '';
  constructor(
    private productService: ProductStoreService,
    private adminProductService: AdminProductStoreService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    this.id = this.route.snapshot.params['id'];
    this.productService.getById(this.id).subscribe({
      next: (product) => {
        this.characteristic = product.characteristics ?? [];
      },
    });
  }

  characteristic: CharacteristicModel[] = [];

  model = {} as CharacteristicModel;

  gr: CharacteristicModel[] = [];
  entity = {} as CharacteristicModel;
  isAction: boolean = false;

  addCharacteristic() {
    this.model = {
      key: '',
      value: '',
      isGroup: false,
      _disabled: false,
      children: [],
    };
    this.characteristic.push(this.model);
    this.isAction = true;
  }

  addGroupBetween(group: CharacteristicModel) {
    this.model = {
      key: '',
      value: '',
      isGroup: true,
      _disabled: false,
      children: [],
    };
    this.gr = this.characteristic.slice(
      0,
      this.characteristic.indexOf(group) + 1,
    );
    this.gr.push(this.model);
    this.gr.push(
      ...this.characteristic.slice(this.characteristic.indexOf(group) + 1),
    );
    this.characteristic = this.gr;
    this.isAction = true;
    this.gr = [];
  }

  addCharacteristicBetween(group: CharacteristicModel) {
    this.model = {
      key: '',
      value: '',
      isGroup: false,
      _disabled: false,
      children: [],
    };
    this.gr = this.characteristic.slice(
      0,
      this.characteristic.indexOf(group) + 1,
    );
    this.gr.push(this.model);
    this.gr.push(
      ...this.characteristic.slice(this.characteristic.indexOf(group) + 1),
    );
    this.characteristic = this.gr;
    this.isAction = true;
    this.gr = [];
  }

  confirmCharacteristic() {
    this.model = {} as CharacteristicModel;
    this.isAction = false;
  }

  removeCharacteristic(key: string) {
    this.characteristic = this.characteristic.filter(
      (c) => c.key == key && !c.isGroup,
    );
    this.isAction = false;
  }

  addGroup() {
    this.characteristic.push({
      key: '',
      value: '',
      isGroup: true,
      _disabled: false,
      children: [],
    });
    this.isAction = true;
  }

  confirmGroup() {
    this.isAction = false;
  }

  removeGroup(group: CharacteristicModel) {
    this.characteristic = this.characteristic.filter(
      (g) => g.key !== group.key && g.isGroup,
    );
    this.isAction = false;
  }

  addCharacteristicToGroup(group: CharacteristicModel) {
    this.model = {
      key: '',
      value: '',
      isGroup: false,
      _disabled: false,
      children: [],
    };
    this.characteristic
      .find((g) => g.key === group.key)
      ?.children.push(this.model);
    this.isAction = true;
  }

  confirmCharacteristicGroup(group: CharacteristicModel) {
    this.model = {} as CharacteristicModel;
    this.isAction = false;
  }

  save() {
    this.adminProductService
      .updateCharacteristic(this.id, JSON.stringify(this.characteristic))
      .subscribe({
        next: () => {},
      });
  }

  back() {
    this.router.navigate(['admin/product']);
  }
}
