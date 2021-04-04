# cart api

dotnet core api to interact with database for the add to cart operation 

## prerequisites

* dotnet core sdk 5.0 
* docker

## usage

* run `docker-compose up` in src folder
* go to `http://localhost:8090/swagger`
* list variants that are seeded by ef core over `/api/variant/variants`
* pick one and try to add to cart over `/api/cart/add-to-cart`
