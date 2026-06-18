## Add nginx Config /etc/nginx/sites-available/default
```
server {
server_name   college.itstep.click *.college.itstep.click;
client_max_body_size 250M;
location / {
        proxy_pass         http://localhost:4961;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }

}


sudo systemctl restart nginx
```

