package teistermask.bindingModel;

public class TaskBindingModel {
    private String title;
	private String status;

	public String getTitle() {
		return this.title;
	}

	public String setTitle(String title) {
		return this.title = title;
	}

	public String getStatus() {
		return this.status;
	}

	public void setStatus(String status) {
		this.status = status;
	}
}
