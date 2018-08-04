# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/xenial64"
  config.vm.synced_folder "../AngularNetCore", "/home/vagrant/vagrant"
  config.vm.network "private_network", ip: "192.168.108.10"
  config.vm.provider "virtualbox" do |v|
    v.customize ["modifyvm", :id, "--uartmode1", "disconnected" ]
  end
end
