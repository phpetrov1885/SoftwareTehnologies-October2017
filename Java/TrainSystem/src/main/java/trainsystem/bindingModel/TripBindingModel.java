package trainsystem.bindingModel;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class TripBindingModel {
    @NotNull
    @Size(min = 1)
    private String origin;

    @NotNull
    @Size(min = 1)
    private String destination;

    private int business;

    private int economy;

    public TripBindingModel() {
    }

    public TripBindingModel(String origin, String destination, int business, int economy) {
        this.origin = origin;
        this.destination = destination;
        this.business = business;
        this.economy = economy;
    }

    public String getOrigin() {
        return origin;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public int getBusiness() {
        return business;
    }

    public void setBusiness(int business) {
        this.business = business;
    }

    public int getEconomy() {
        return economy;
    }

    public void setEconomy(int economy) {
        this.economy = economy;
    }
}
