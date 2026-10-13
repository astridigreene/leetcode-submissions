class ParkingSystem:

    def __init__(self, big: int, medium: int, small: int):
        self.spaces_available = {}
        self.spaces_available[1] = big
        self.spaces_available[2] = medium
        self.spaces_available[3] = small

    def addCar(self, carType: int) -> bool:
        if self.spaces_available[carType] > 0:
            self.spaces_available[carType] -= 1
            return True
        return False


# Your ParkingSystem object will be instantiated and called as such:
# obj = ParkingSystem(big, medium, small)
# param_1 = obj.addCar(carType)