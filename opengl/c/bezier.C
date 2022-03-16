#include <GL/glut.h>
#include <armadillo>

void bezier3(int points, arma::frowvec b0, arma::frowvec b1, arma::frowvec b2, arma::frowvec b3)
{
    arma::fmat T(points, 4);
    float inc = 1.0 / points;
    int index = 0;
    for (float t = 0; t <= 1.0 && index < points; t += inc)
        T.row(index++) = arma::frowvec({t * t * t, t * t, t, 1.0});
    arma::fmat N({{-1, 3, -3, 1}, {3, -6, 3, 0}, {-3, 3, 0, 0}, {1, 0, 0, 0}});
    arma::fmat B = arma::join_cols(b0, b1, b2, b3);
    arma::fmat V = T * N * B;

    glColor3f(1, 0, 0);
    glPointSize(3);
    glBegin(GL_POINTS);
    // std::cout << "size" << arma::size(V) << std::endl;
    // V.print();
    for (int i = 0; i < points; ++i)
    {
        // std::cout << B.row(i) << std::endl;
        glVertex2f(V(i, 0), V(i, 1));
    }
    glEnd();
    glFlush();
}

void display()
{
    auto b0 = arma::frowvec({0, 0});
    auto b1 = arma::frowvec({0, 0.5});
    auto b2 = arma::frowvec({0.5, 0.5});
    auto b3 = arma::frowvec({0.5, 0});

    glClear(GL_COLOR_BUFFER_BIT);

    int points = 1000;
    bezier3(points, b0, b1, b2, b3);
}

int main(int argc, char **argv)

{
    // std::cout << R.size();
    glutInit(&argc, argv);
    glutCreateWindow("Rotate");
    glutDisplayFunc(display);
    glutMainLoop();
}