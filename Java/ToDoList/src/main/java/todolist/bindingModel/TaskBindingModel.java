package todolist.bindingModel;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class TaskBindingModel {
	@NotNull
    @Size(min=1)
    private String Title;

    @NotNull
    @Size(min=1)
    private String Comments;

    public TaskBindingModel(String title, String comments) {
        Title = title;
        Comments = comments;
    }

    public TaskBindingModel() {
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public String getComments() {
        return Comments;
    }

    public void setComments(String comments) {
        Comments = comments;
    }
}
