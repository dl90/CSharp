export class MyDataService {
  names: Array<any>

  constructor () {
    this.names = ['John', 'Mary', 'Joan']
  }

  getNames = () => this.names
  myName = () => 'Don Li'
}
