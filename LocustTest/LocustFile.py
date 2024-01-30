from locust import HttpUser, task
from locust.user.task import TaskSetMeta
import random;


class TestClass(HttpUser):
    @task
    def go_to_homepage(self):
        self.client.get("/")
        
    @task
    def go_to_CarInfo(self):
        self.client.get("/Cars/Info/" + str(random.randint(1,4)))
        
    @task
    def go_to_CarCreate(self):
        self.client.get("/Cars/Create")
