
import com.jogamp.opengl.GL;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.glu.GLU;

public class OneTriangle {

    protected static void setup(GL gl, int width, int height) {

    }

    protected static void render(GL _gl, int width, int height) {
        GL2 gl = _gl.getGL2();
        gl.glClear(GL.GL_COLOR_BUFFER_BIT);

        // draw a triangle filling the window
//        gl.glLoadIdentity();
        gl.glColor3f(1, 0, 0);
        gl.glBegin(GL2.GL_POLYGON);
        gl.glVertex2f(0f, 0f);
        gl.glVertex2f(0.2f, 0f);
        gl.glVertex2f(0.2f, 0.5f);
//        gl.glVertex3f(0f, 1f, 0);

        gl.glEnd();
    }
}
